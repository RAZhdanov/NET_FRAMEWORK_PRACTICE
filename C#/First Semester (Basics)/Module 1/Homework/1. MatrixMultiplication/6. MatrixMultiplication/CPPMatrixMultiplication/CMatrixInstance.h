#pragma once
#include "stdafx.h"

class CMatrixInstance
{
public:
	ULONGLONG GetStartTick(void) const;
	ULONGLONG GetEndTick(void) const;
	class Proxy
	{
	public:
		Proxy(const double *_array) : m_array(_array), m_columns(COLUMN_LENGTH)
		{
		}
		Proxy(const Proxy &rval)
		{
			if (this != &rval)
			{
				*this = rval;
			}
		}
		const double& operator[](const unsigned int index)
		{
			return m_array[index];
		}

	private:
		const double *m_array;
		int m_columns;
	};
	Proxy operator[](const unsigned int i) const;
public:
	CMatrixInstance();
	CMatrixInstance(double arr_two_dimensional_array[ROW_LENGTH][COLUMN_LENGTH], ULONGLONG lStartTick = 0, ULONGLONG lEndTick = 0);
	CMatrixInstance(const CMatrixInstance& rval);
	virtual ~CMatrixInstance();
public:
	void RandomMixing();

public:
	CMatrixInstance operator*(const CMatrixInstance& rval) const;
	CMatrixInstance& operator=(const CMatrixInstance& rval);
private:
	unsigned int m_rowCount, m_colCount;
	double m_array[ROW_LENGTH][COLUMN_LENGTH];
private:
	void SetStartTick(ULONGLONG _lStartTick);
	void SetEndTick(ULONGLONG _lEndTick);

	ULONGLONG m_lStartTick;
	ULONGLONG m_lEndTick;
};

