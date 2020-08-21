#pragma once
#include "stdafx.h"
//In terms of address representation it is a jagged array, 
//because the first pointer of this array could reference to another array with any created length.
class CJaggedMatrixInstance
{
public:
	
	ULONGLONG GetStartTick(void) const;
	ULONGLONG GetEndTick(void) const;
public:
	CJaggedMatrixInstance(void);
	CJaggedMatrixInstance(const CJaggedMatrixInstance&);
	CJaggedMatrixInstance(unsigned int _rowCount, unsigned int _colCount);
	
	class Proxy
	{
	public:
		Proxy(double * _array, const int colomns) : m_array(_array), m_columns(colomns){}
		Proxy(const Proxy &rval)
		{
			if (this != &rval)
			{
				*this = rval;
			}
		}
		double& operator[](const unsigned int index)
		{
			return m_array[index];
		}
	private:
		double *m_array;
		int m_columns;
	};

	CJaggedMatrixInstance operator*(const CJaggedMatrixInstance& rval) const;
	CJaggedMatrixInstance& operator=(const CJaggedMatrixInstance& rval);
	Proxy operator[](const unsigned int i) const;


	const unsigned int GetRowCount() const;
	const unsigned int GetColCount() const;

	void SetValue(int _rowCount, int _colCount, double value);
	double GetValue(int _rowCount, int _colCount) const;

	void RandomMixing();

	virtual ~CJaggedMatrixInstance();

private:
	unsigned int m_rowCount, m_colCount;

	//double &m_two_dimentional_array[ROW_LENGTH][COLUMN_LENGTH];
	double **m_array; //массив
private:
	void ArrayZeroMemory();
	void SetStartTick(ULONGLONG _lStartTick);
	void SetEndTick(ULONGLONG _lEndTick);

	ULONGLONG m_lStartTick;
	ULONGLONG m_lEndTick;
};

