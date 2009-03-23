#include "stdafx.h"
#include <ksh/RungeKutta.h>
#include <ksh/Array.h>
#include <ksh/Vector.h>
#include "I_A2.h"

typedef ksh::Array<double,2> array_t;

void Poisson(array_t& phi,const array_t& rho,double dx,double dy,bool (*error_evaluator)(double val,double delta)){
	const int MAX_LOOP=1000;
	const double cSOR=1.5; // âﬂèËä…òaåWêî

	dx*=dx;
	dy*=dy;
	const double den=0.5/(dx+dy);

	for(int iloop=0;iloop<MAX_LOOP;iloop++){
		bool ok=true;

		ksh::IntRange dim1(rho.range1().start()+1,rho.range1().end()-1);
		ksh::IntRange dim2(rho.range2().start()+1,rho.range2().end()-1);
		ksh::iterator_index<array_t> i(dim1,dim2);
		ksh::iterator_index<array_t>::binder iphi(phi,i);
		ksh::iterator_index<array_t>::const_binder irho(rho,i);
		while(!i.isEnd()){
			double dphi=den*(dx*(iphi(1,0)+iphi(-1,0))+dy*(iphi(0,1)+iphi(0,-1))+dx*dy**irho)-*iphi;
			*iphi+=cSOR*dphi;
			ok=ok&&error_evaluator(*iphi,dphi);
			i++;
		}

		if(ok)break;
	}
}

void Poisson(array_t& phi,const array_t& rho,double dx,double dy,double err_thre){
	const int MAX_LOOP=1000;
	const double cSOR=1.5; // âﬂèËä…òaåWêî

	dx*=dx;
	dy*=dy;
	const double den=0.5/(dx+dy);

	const int xS=phi.range1().start()+1;
	const int yS=phi.range2().start()+1;
	const int xM=phi.range1().end()-1;
	const int yM=phi.range2().end()-1;

	for(int iloop=0;iloop<MAX_LOOP;iloop++){
		double dphi_max=0;

		for(int x=xS;x<xM;x++){
			for(int y=yS;y<yM;y++){
				double dphi=den*(dx*(phi(x+1,y)+phi(x-1,y))+dy*(phi(x,y+1)+phi(x,y-1))+dx*dy*rho(x,y))-phi(x,y);
				phi(x,y)+=cSOR*dphi;
				dphi_max=std::max(dphi_max,dphi);
			}
		}
		for(int x=xS;x<xM;x++){
			phi(x,0)=phi(x,1);
			phi(x,yM)=phi(x,yM-1);
		}
		for(int y=yS;y<yM;y++){
			phi(0,y)=phi(1,y);
			phi(xM,y)=phi(xM-1,y);
		}

		if(dphi_max<=err_thre)break;
	}
}

void MAC01Test01(){
	ksh::Array<double,2> y(10,10);
	y.clear(0);

	typedef ksh::iterator_index<ksh::Array<double,2>> iterator_index;
	iterator_index i(ksh::IntRange(2,9),ksh::IntRange(1,5));
	iterator_index::binder ix(y,i);
	while(!i.isEnd()){
		*ix=1;

		i++;
	}

	typedef ksh::iterator<ksh::Array<double,2>> iterator;
	for(iterator i(y);!i.isEnd();i++){
		std::cout<<*i<<" ";
		if(i.index_x()+1==10)
			std::cout<<std::endl;
	}
}

namespace MAC01{
	typedef ksh::Array<double,2> array_t;
	typedef ksh::Array<ksh::Vector2<double>,2> array2_t;

	const int N=10;
	const double d=1;
	const double NU=1;
	const double dt=0.001;

	// SOR
	const int SOR_MAX_LOOP=1000;
	const double cSOR=1.5; // âﬂèËä…òaåWêî
	const double SOR_ERR_THRE=1e-8;

	void init();
	void diff(array2_t& vec_f,const array2_t& vec_v,double t);
	void step();
	void poisson(array_t& phi,const array_t& rho);

	array2_t vec_v(N,N);
	array2_t buff_v(N,N);
	array_t p(N,N);
	array_t pBuff(N,N);

	ksh::ERKIntegrator<array2_t>* integ;

	void init(){
		vec_v.clear(ksh::Vector2<double>(0,0));
		for(int i=0;i<N;i++){
			vec_v(i,0).x=1.0;
		}

		p.clear(0);
		pBuff.clear(0);

		integ=new ksh::ERKIntegrator<array2_t>(vec_v);
	}

	void step(){
		integ->step(vec_v,diff,dt);
	}

	void diff(array2_t& vec_f,const array2_t& vec_v,double t){
#define for_loop(x)	for(int x=1;x<N-1;x++)
#define u(X,Y)	vec_v(X,Y).x
#define v(X,Y)	vec_v(X,Y).y
		// P ÇÃçXêV
		for_loop(x)for_loop(y){
			double u_x=u(x+1,y)-u(x-1,y);
			double u_y=u(x,y+1)-u(x,y-1);
			double v_x=v(x+1,y)-v(x-1,y);
			double v_y=v(x,y+1)-v(x,y-1);
			pBuff(x,y)=-(u_x*u_x+2*u_y*v_x+v_y*v_y);
		}
		poisson(p,pBuff);

		// V ÇÃçXêV
		for_loop(x)for_loop(y){
			double trs,div;

			trs=(1/d)*(
				-(p(x+1,y)-p(x-1,y))
				-v(x,y)*(u(x,y+1)-u(x,y-1))
				-u(x,y)*(u(x+1,y)-u(x-1,y))
			);
			div=(NU/d*d)*(
				u(x+1,y)-2*u(x,y)+u(x-1,y)
				+u(x,y+1)-2*u(x,y)+u(x,y-1)
			);
			vec_f(x,y).x=trs+div;

			trs=(1/d)*(
				-(p(x+1,y)-p(x-1,y))
				-u(x,y)*(v(x+1,y)-v(x-1,y))
				-v(x,y)*(v(x,y+1)-v(x,y-1))
			);
			div=(NU/d*d)*(
				v(x+1,y)-2*v(x,y)+v(x-1,y)
				+v(x,y+1)-2*v(x,y)+v(x,y-1)
			);
			vec_f(x,y).y=trs+div;
		}
#undef v
#undef u
	}

	void poisson(array_t& phi,const array_t& rho){
		for(int iloop=0;iloop<SOR_MAX_LOOP;iloop++){
			double dphi_max=0;

			for_loop(x)for_loop(y){
				double dphi=0.25*((phi(x+1,y)+phi(x-1,y))+(phi(x,y+1)+phi(x,y-1))+(d*d)*rho(x,y))-phi(x,y);
				phi(x,y)+=cSOR*dphi;
				dphi_max=std::max(dphi_max,dphi);
			}
			for_loop(x){
				phi(x,0)=phi(x,1);
				phi(x,N)=phi(x,N-1);
			}
			for_loop(y){
				phi(0,y)=phi(1,y);
				phi(N,y)=phi(N-1,y);
			}

			if(dphi_max<=SOR_ERR_THRE)break;
		}
	}

}
