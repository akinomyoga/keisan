#pragma once
#include <ksh/Array.h>

namespace ksh{
	template<typename T,typename self_t> class iterator_base;
	template<typename T> class iterator_index;
	template<typename T> class iterator;
	template<typename T> class const_iterator;

	template<typename T,typename self_t>
	class iterator_base<ksh::Array<T,2>,self_t>{
	protected:
		typedef Array<T,2> array_t;
		typedef iterator_base<ksh::Array<T,2>,self_t> accessor_t;
	
		IntRange dim1;
		IntRange dim2;
		int x;
		int y;
	public:
		iterator_base(const array_t& arr)
			:dim1(arr.range1()),dim2(arr.range2())
		{
			this->x=dim1.start();
			this->y=dim2.start();
		}
		iterator_base(const IntRange& dim1,const IntRange& dim2)
			:dim1(dim1),dim2(dim2)
		{
			this->x=dim1.start();
			this->y=dim2.start();
		}
		int index_x() const{return this->x;}
		int index_y() const{return this->y;}
		bool isEnd() const{
			return this->y>=dim2.end();
		}
		bool inRange() const{
			return dim2.start()<=y&&y<dim2.end();
		}
		//============================================================
		//		iterator
		//============================================================
		self_t& operator--(void){
			if(x--==dim1.start()){
				x=dim1.end()-1;
				y--;
			}
			return *static_cast<self_t*>(this);
		}
		self_t operator--(int){
			self_t ret=*static_cast<self_t*>(this);
			--*this;
			return ret;
		}
		self_t& operator++(void){
			if(++x==dim1.end()){
				x=dim1.start();
				++y;
			}
			return *static_cast<self_t*>(this);
		}
		self_t operator++(int){
			self_t ret=*static_cast<self_t*>(this);
			++*this;
			return ret;
		}
	public:
		struct binder{
			array_t& arr;
			const iterator_base& it;
			binder(array_t& arr,const iterator_base& it):arr(arr),it(it){}

			inline T& operator*() const{
				return it.value(arr);
			}
			inline T& operator()(int dx,int dy) const{
				return it.value(arr,dx,dy);
			}
		};
		struct const_binder{
			const array_t& arr;
			const iterator_base& it;
			const_binder(const array_t& arr,const iterator_base& it):arr(arr),it(it){}

			inline T operator*() const{
				return it.value(arr);
			}
			inline T operator()(int dx,int dy) const{
				return it.value(arr,dx,dy);
			}
		};
	protected:
		T& value(array_t& arr) const{
			return arr(x,y);
		}
		T& value(array_t& arr,int dx,int dy) const{
			return arr(x+dx,y+dy);
		}
		T value(const array_t& arr) const{
			return arr(x,y);
		}
		T value(const array_t& arr,int dx,int dy) const{
			return arr(x+dx,y+dy);
		}
	};

	template<typename T>
	class iterator_index<Array<T,2>>
		:public iterator_base<Array<T,2>,iterator_index<Array<T,2>>>
	{
	public:
		iterator_index(const IntRange& dim1,const IntRange& dim2)
			:accessor_t(dim1,dim2){}
	};

	template<typename T>
	class iterator<Array<T,2>>
		:public iterator_base<Array<T,2>,iterator<Array<T,2>>>
		,public std::iterator<std::bidirectional_iterator_tag,T>
	{
		typedef Array<T,2> array_t;

		array_t& arr;
	public:
		iterator(array_t& arr)
			:arr(arr),accessor_t(arr){}
		iterator(array_t& arr,const IntRange& dim1,const IntRange& dim2)
			:arr(arr),accessor_t(dim1,dim2){}

		T& operator*() const{
			return this->value(arr);
		}
		T& operator()(int dx,int dy) const{
			return this->value(arr,dx,dy);
		}
	};

	template<typename T>
	class const_iterator<Array<T,2>>
		:public iterator_base<Array<T,2>,const_iterator<Array<T,2>>>
		,public std::iterator<std::bidirectional_iterator_tag,T>
	{
		typedef Array<T,2> array_t;

		const array_t& arr;
	public:
		const_iterator(const array_t& arr)
			:arr(arr),accessor_t(arr){}
		const_iterator(const array_t& arr,const IntRange& dim1,const IntRange& dim2)
			:arr(arr),accessor_t(dim1,dim2){}

		T& operator*() const{
			return this->value(arr);
		}
		T& operator()(int dx,int dy) const{
			return this->value(arr,dx,dy);
		}
	};
}
