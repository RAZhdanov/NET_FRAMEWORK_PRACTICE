// CPPMatrixMultiplication.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"

#include <iostream>

#include <memory>
#include "CMatrixInstance.h"
#include "CJaggedMatrixInstance.h"
#include "CException.h"
#include <string>

#include <time.h>




int main(int argc, char *argv[])
{
	srand((unsigned int)time(NULL)); //Creating of pseuso-random number generation
	int n1 = 0, n2 = 0;
	if (argc == 3)
	{
		n1 = atoi(argv[1]);
		n2 = atoi(argv[2]);
	}
	else //by default
	{
		n1 = 10;
		n2 = 10;
	}

	//PART 1: MULTIPLICATION OF MULTIDIMENSIONAL ARRAYS
	//Sizes of ROW_LENGTH and COLUMN_LENGTH are predefined in stdafx.h - applicable only for static arrays!!!

	CMatrixInstance matrix_a;
	matrix_a.RandomMixing();
	
	CMatrixInstance matrix_b;
	matrix_b.RandomMixing();

	CMatrixInstance matrix_res;
	matrix_res = matrix_a * matrix_b;

	// Простое засечение времени
	auto dwDurationOfMultiplicationOfArrays = matrix_res.GetEndTick() - matrix_res.GetStartTick();

	//PRINTING OUTPUT DATA
	for (unsigned int i = 0; i < ROW_LENGTH; i++)
	{
		for (unsigned int j = 0; j < COLUMN_LENGTH; j++)
		{
			char buffer[256];
			sprintf_s(buffer, "res[%d][%d] = %lf", i, j, matrix_res[i][j]);
			std::cout << buffer << std::endl;
		}
	}
	std::cout << "Duration of multiplication of 2 matrixes is " << dwDurationOfMultiplicationOfArrays << "ms" << std::endl;
	system("pause");


	
	//PART 2: MULTIPLICATION OF 2 JAGGED-LIKE ARRAYS
	//Herein we create dynamic arrays whose address representation is very close to jagged-arrays.
	CJaggedMatrixInstance jagged_matrixA(n1, n2);
	jagged_matrixA.RandomMixing();


	CJaggedMatrixInstance jagged_matrixB(n1, n2);
	jagged_matrixB.RandomMixing();

	CJaggedMatrixInstance jagged_matrixRes = jagged_matrixA * jagged_matrixB;

	// Простое засечение времени
	auto dwDurationOfMultiplicationOfJaggedArrays = jagged_matrixRes.GetEndTick() - jagged_matrixRes.GetStartTick();


	//PRINTING OUTPUT DATA
	std::cout << "Print all variables from output jagged-like array" << std::endl;
	for (unsigned int i = 0; i < jagged_matrixRes.GetRowCount(); i++)
	{
		for (unsigned int j = 0; j < jagged_matrixRes.GetColCount(); j++)
		{
			char buffer[256];
			sprintf_s(buffer, "res[%d][%d] = %lf", i, j, jagged_matrixRes[i][j]);
			std::cout << buffer << std::endl;
		}
	}

	
	std::cout << "Duration of multiplication of 2 jagged-like matrixes is " << dwDurationOfMultiplicationOfJaggedArrays << "ms" << std::endl;

	system("pause");
	return 0;
}
