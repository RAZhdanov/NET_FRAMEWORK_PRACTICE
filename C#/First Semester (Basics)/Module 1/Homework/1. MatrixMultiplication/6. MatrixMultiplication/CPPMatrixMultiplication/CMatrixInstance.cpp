#include "pch.h"
#include "CMatrixInstance.h"


CMatrixInstance::CMatrixInstance()
{
	std::cout << "Default Constructor" << std::endl;
	m_rowCount = m_colCount = COLUMN_LENGTH;
	m_lStartTick = 0;
	m_lEndTick = 0;
	ZeroMemory(m_array, COLUMN_LENGTH*COLUMN_LENGTH * sizeof(double));
}

CMatrixInstance::CMatrixInstance(double arr_two_dimensional_array[ROW_LENGTH][COLUMN_LENGTH], ULONGLONG lStartTick, ULONGLONG lEndTick)
{
	std::cout << "Full Constructor" << std::endl;
	m_rowCount = m_colCount = COLUMN_LENGTH;
	m_lStartTick = lStartTick;
	m_lEndTick = lEndTick;
	for (unsigned int i = 0; i < ROW_LENGTH; i++)
	{
		for (unsigned int j = 0; j < COLUMN_LENGTH; j++)
		{
			m_array[i][j] = arr_two_dimensional_array[i][j];
		}
	}
}
void CMatrixInstance::RandomMixing()
{
	std::cout << "RandomMixing!" << std::endl;
	//initialization
	{
		for (unsigned int i = 0; i < m_rowCount; i++)
		{
			for (unsigned int j = 0; j < m_colCount; j++)
			{
				int nRand = abs(rand());
				m_array[i][j] = nRand;
			}
		}
	}
}
//copy constructor
CMatrixInstance::CMatrixInstance(const CMatrixInstance& rval)
{
	std::cout << "Copy Constructor!!!" << std::endl;
	//self-assignment check
	if (this != &rval)
	{
		*this = rval;
	}
}

CMatrixInstance CMatrixInstance::operator*(const CMatrixInstance & rval) const
{
	double res_matrix[ROW_LENGTH][COLUMN_LENGTH] = { 0 };

	ULONGLONG lStart = GetTickCount64(); //Начало тика
	{
		//Ожидается, что результат умножения возвращается, а множители не меняются
		for (unsigned int i = 0; i < m_rowCount; i++)
		{
			for (unsigned int j = 0; j < m_colCount; j++)
			{
				double cc = 0;
				for (unsigned int k = 0; k < m_rowCount; k++)
				{
					cc += (m_array[i][k] * rval[k][j]);
				}
				res_matrix[i][j] = cc;
			}
		}
	}
	ULONGLONG lEnd = GetTickCount64(); //Завершение тика

	return CMatrixInstance(res_matrix, lStart, lEnd);
}

CMatrixInstance::Proxy CMatrixInstance::operator[](const unsigned int i) const
{
	Proxy proxy(m_array[i]);
	return proxy;
}

CMatrixInstance& CMatrixInstance::operator=(const CMatrixInstance& rval)
{
	//self-assignment check
	if (this != &rval)
	{
		for (unsigned int i = 0; i < this->m_colCount; i++)
		{
			for (unsigned int j = 0; j < this->m_rowCount; j++)
			{
				m_array[i][j] = rval.m_array[i][j];
			}
		}		

		this->m_colCount = rval.m_colCount;
		this->m_rowCount = rval.m_rowCount;
		this->m_lStartTick = rval.m_lStartTick;
		this->m_lEndTick = rval.m_lEndTick;
	}
	return *this;
}

CMatrixInstance::~CMatrixInstance()
{
	std::cout << "Destructor of static array" << std::endl;
}

void CMatrixInstance::SetStartTick(ULONGLONG _lStartTick)
{
	m_lStartTick = _lStartTick;
}
void CMatrixInstance::SetEndTick(ULONGLONG _lEndTick)
{
	m_lEndTick = _lEndTick;
}

ULONGLONG CMatrixInstance::GetStartTick(void) const
{
	return m_lStartTick;
}
ULONGLONG CMatrixInstance::GetEndTick(void) const
{
	return m_lEndTick;
}