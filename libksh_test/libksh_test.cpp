// libksh_test.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"
#define KSH_MATRIX_IMPLEMENTATION
#include <ksh/RungeKutta.h>
#include <ksh/Linear.h>

#include <conio.h>

double init(int i,int j){
	return i*j;
}

typedef ksh::LinearSpace::Matrix<double> matrix_t;
typedef ksh::LinearSpace::Allocator allocator;
int _tmain(int argc, _TCHAR* argv[]){
	{
		allocator::Context ctx;
		allocator::Cache<double,3> cache(10*10);

		matrix_t mat(10,init);
		mat+=mat;

		matrix_t b(10,init);
		b-=mat;
		mat=b+mat;

		std::cout<<mat;
	}

	void retard();
	retard();

	void MAC01Test01();
	MAC01Test01();

	::_getch();
	return 0;
}

