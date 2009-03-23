#include "stdafx.h"
#include <ksh/Array.h>
//#include <ksh/RungeKutta.h>

template<typename T>
class Expression{
	class EvalBase{
	public:
		EvalBase(){}
		virtual void eval(T& result)=0;

		T eval(){
			T ret;
			eval(ret);
			return ret;
		}
	};

	template<typename Elem>
	class Evaluator:public EvalBase{
		Elem& e;
	public:
		Evaluator(Elem& elem):e(elem){}
		void eval(T& result){
			result=e.eval();
		}
	};

	EvalBase* pEval;
public:
	template<typename Elem>
	Expression(Elem& elem):pEval(new Evaluator<Elem>(elem)){}
	~Expression(){delete this->pEval;}

	T eval(){
		return this->pEval->eval();
	}
public:
	class VarRef{
		T* value;
	public:
		VarRef():value(nullptr){}
		~VarRef(){}

		T eval(){return *value;}

		void set_ref(T& val){
			this->value=&val;
		}
	};

	template<typename Elem>
	class Negate{
		Elem& v;
	public:
		Negate(Elem& elem):v(elem){}
		T eval(){return -v.eval();}
	};

	template<typename Elem>
	static Negate<Elem> neg(Elem& x){
		return Negate<Elem>(x);
	}
};

template<>
class Expression<ksh::Array<double>>{
	typedef double T;
	typedef ksh::Array<double> array_t;
private:
	class EvalBase{
	public:
		EvalBase(){}
		virtual void eval(array_t& result)=0;
	};

	template<typename Elem>
	class Evaluator:public EvalBase{
		Elem& e;
	public:
		Evaluator(Elem& elem):e(elem){}
		void eval(array_t& result){
			for(int i=0;i<100;i++){
				T val;
				e.eval(val,index);
				result[i]=val;
			}
		}
	};

	EvalBase* pEval;
public:
	template<typename Elem>
	Expression(Elem& elem):pEval(new Evaluator<Elem>(elem)){}
	~Expression(){delete this->pEval;}

	void eval(array_t& result){
		return this->pEval->eval(result);
	}
public:
	template<typename Elem>
	class neg;
	template<typename TL,typename TR>
	class add;
	template<typename TL,typename TR>
	class sub;
	template<typename TL,typename TR>
	class mul;
	template<typename TL,typename TR>
	class div;

	template<typename TS>
	class ElemBase{
	public:
		neg<TS> operator-(){
			TS& _this=static_cast<TS>(*this);
			return neg<TS>(_this);
		}
		TS operator+(){
			TS& _this=static_cast<TS>(*this);
			return _this;
		}
		template<typename TR>
		add<TS,TR> operator+(const TR& right){
			TS& left=static_cast<TS>(*this);
			return add<TS,TR>(left,right);
		}
		template<typename TR>
		sub<TS,TR> operator-(const TR& right){
			TS& left=static_cast<TS>(*this);
			return sub<TS,TR>(left,right);
		}
		template<typename TR>
		mul<TS,TR> operator*(const TR& right){
			TS& left=static_cast<TS>(*this);
			return mul<TS,TR>(left,right);
		}
		template<typename TR>
		div<TS,TR> operator/(const TR& right){
			TS& left=static_cast<TS>(*this);
			return div<TS,TR>(left,right);
		}
	};

	class VarRef:public ElemBase<VarRef>{
		array_t* arr;
	public:
		VarRef():arr(nullptr){}
		~VarRef(){}

		void eval(T& value,int index){
			value=(*this->arr)[index];
		}

		void set_ref(array_t& arr){
			this->arr=&arr;
		}
	};

	template<typename Elem>
	class neg:public ElemBase<neg<Elem>>{
		Elem& v;
	public:
		neg(const Elem& elem):v(elem){}

		void eval(T& value,int index){
			this->v.eval(value,index);
			value=-value;
		}
	};

	template<typename TL,typename TR>
	class add:public ElemBase<add<TL,TR>>{
		TL& l;
		TR& r;
	public:
		add(const TL& l,const TR& r):l(l),r(r){}

		void eval(T& value,int index){
			T left,right;
			this->l.eval(left,index);
			this->r.eval(right,index);
			value=left+right;
		}
	};

	template<typename TL,typename TR>
	class sub:public ElemBase<sub<TL,TR>>{
		TL& l;
		TR& r;
	public:
		sub(const TL& l,const TR& r):l(l),r(r){}

		void eval(T& value,int index){
			T left,right;
			this->l.eval(left,index);
			this->r.eval(right,index);
			value=left-right;
		}
	};

	template<typename TL,typename TR>
	class mul:public ElemBase<mul<TL,TR>>{
		TL& l;
		TR& r;
	public:
		mul(const TL& l,const TR& r):l(l),r(r){}

		void eval(T& value,int index){
			T left,right;
			this->l.eval(left,index);
			this->r.eval(right,index);
			value=left*right;
		}
	};

	template<typename TL,typename TR>
	class div:public ElemBase<div<TL,TR>>{
		TL& l;
		TR& r;
	public:
		div(const TL& l,const TR& r):l(l),r(r){}

		void eval(T& value,int index){
			T left,right;
			this->l.eval(left,index);
			this->r.eval(right,index);
			value=left/right;
		}
	};
};

void retard(){
	typedef Expression<double> Xpr;

	Xpr::VarRef x;
	Xpr e=Xpr::neg(x);

	double n=100;
	x.set_ref(n);
	std::cout<<e.eval()<<std::endl;
}