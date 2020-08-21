#include "pch.h"
#include "CJaggedMatrixInstance.h"

//default-constructor
CJaggedMatrixInstance::CJaggedMatrixInstance(void): CJaggedMatrixInstance(0,0)
{
	m_lStartTick = 0;
	m_lEndTick = 0;
	std::cout << "Default Constructor!!!" << std::endl;
}
//full-constructor
CJaggedMatrixInstance::CJaggedMatrixInstance(unsigned int _rowCount, unsigned int _colCount) : m_rowCount(_rowCount), m_colCount(_colCount)
{
	m_lStartTick = 0;
	m_lEndTick = 0;
	std::cout << "Constructor!!!" << std::endl;
	//memory allocation
	{
		m_array = new double*[m_rowCount];

		for (unsigned int i = 0; i < m_rowCount; i++)
		{
			m_array[i] = new double[m_colCount];
		}
	}
	ArrayZeroMemory();
}

//copy constructor
CJaggedMatrixInstance::CJaggedMatrixInstance(const CJaggedMatrixInstance& rval)
{
	std::cout << "Copy Constructor!!!" << std::endl;
	//self-assignment check
	if (this != &rval)
	{
		*this = rval;
	}
}
const unsigned int CJaggedMatrixInstance::GetRowCount() const
{
	return m_rowCount;
}
const unsigned int CJaggedMatrixInstance::GetColCount() const
{
	return m_colCount;
}

void CJaggedMatrixInstance::ArrayZeroMemory()
{
	std::cout << "ArrayZeroMemory!" << std::endl;
	//initialization
	{
		for (unsigned int i = 0; i < m_rowCount; i++)
		{
			for (unsigned int j = 0; j < m_colCount; j++)
			{
				m_array[i][j] = 0;
			}
		}
	}
}

void CJaggedMatrixInstance::RandomMixing()
{
	std::cout << "RandomMixing!" << std::endl;
	//initialization
	{
		for (unsigned int i = 0; i < m_rowCount; i++)
		{
			for (unsigned int j = 0; j < m_colCount; j++)
			{
				int nRand = rand();
				m_array[i][j] = abs(nRand);
			}
		}
	}
}
//destructor
CJaggedMatrixInstance::~CJaggedMatrixInstance()
{
	std::cout << "Destructor of dynamic array" << std::endl;
	for (unsigned int i = 0; i < m_rowCount; i++)
	{
		delete[] m_array[i];
	}
	delete m_array;
}

CJaggedMatrixInstance CJaggedMatrixInstance::operator*(const CJaggedMatrixInstance& rval) const
{
	CJaggedMatrixInstance result(m_rowCount, m_colCount);

	result.SetStartTick(GetTickCount64()); //Начало тика
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
				result[i][j] = cc;
			}
		}
	}
	result.SetEndTick(GetTickCount64()); //Завершение тика

	return result;
}
CJaggedMatrixInstance& CJaggedMatrixInstance::operator=(const CJaggedMatrixInstance& rval)
{
	//self-assignment check
	if (this != &rval)
	{
		std::cout << "Assignement Constructor!!!" << std::endl;
		//deletion of invalid data
		{
			for (unsigned int i = 0; i < m_rowCount; i++)
			{
				delete[] m_array[i];
			}
			delete m_array;
		}

		//initialization of private variables from rval
		{
			m_rowCount = rval.GetRowCount();
			m_colCount = rval.GetColCount();
		}

		//memory allocation according to rval
		{
			m_array = new double*[m_rowCount];

			for (unsigned int i = 0; i < m_rowCount; i++)
			{
				m_array[i] = new double[m_colCount];
			}
		}

		//initialization
		{
			for (unsigned int i = 0; i < m_rowCount; i++)
			{
				for (unsigned int j = 0; j < m_colCount; j++)
				{
					m_array[i][j] = rval[i][j];
				}
			}
		}
		m_lStartTick = rval.m_lStartTick;
		m_lEndTick = rval.m_lEndTick;
	}
	return *this;
}

CJaggedMatrixInstance::Proxy CJaggedMatrixInstance::operator[](const unsigned int i) const
{
	Proxy proxy(*m_array, m_colCount);
	return proxy;
}
void CJaggedMatrixInstance::SetValue(int _rowCount, int _colCount, double value)
{
	m_array[_rowCount][_colCount] = value;
}
double CJaggedMatrixInstance::GetValue(int _rowCount, int _colCount) const
{
	return m_array[_rowCount][_colCount];
}

void CJaggedMatrixInstance::SetStartTick(ULONGLONG _lStartTick)
{
	m_lStartTick = _lStartTick;
}
void CJaggedMatrixInstance::SetEndTick(ULONGLONG _lEndTick)
{
	m_lEndTick = _lEndTick;
}

ULONGLONG CJaggedMatrixInstance::GetStartTick(void) const
{
	return m_lStartTick;
}
ULONGLONG CJaggedMatrixInstance::GetEndTick(void) const
{
	return m_lEndTick;
}