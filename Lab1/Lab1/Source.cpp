#include <iostream>
#include <cstdlib>
#include <ctime>

struct Size2D {
	int x;
	int y;
};

class Matrix {

private:
	Size2D size;

	void setSize(Size2D size) {
		if (size.x > 0 && size.y > 0) {
			this->size = size;
		}
		else {
			throw new std::exception("matrix size must be more zero");
		}
	}

public:
	int** values;

	Size2D getSize() {
		return size;
	}

	Matrix(Size2D size, bool setZeroes = false) {
		setSize(size);

		values = new int* [size.x];
		for (int i = 0; i < size.x; i++)
		{
			values[i] = new int[size.y];
			if (setZeroes) {
				for (int j = 0; j < size.y; j++) {
					values[i][j] = 0;
				}
			}
		}
	}

	void show() {

		for (int i = 0; i < size.x; i++)
		{
			for (int j = 0; j < size.x; j++)
			{
				std::cout << values[i][j] << " ";
			}
			std::cout << std::endl;
		}
	}

	void fillValues(bool isRandom = false) {
		switch (isRandom)
		{
		case false:
			for (int i = 0; i < size.x; i++)
				for (int j = 0; j < size.y; j++)
					std::cin >> values[i][j];
			break;
		case true:
			for (int i = 0; i < size.x; i++)
				for (int j = 0; j < size.y; j++)
					values[i][j] = rand() % 10;
			break;
		}
	}

	//matrix.size more or equal this.size
	void fillValues(Matrix* matrix, int i0 = 0, int j0 = 0) {
		try {
			for (int i = 0; i < size.x; i++)
			{
				for (int j = 0; j < size.y; j++)
					this->values[i][j] = matrix->values[i + i0][j + j0];
			}
		}
		catch(std::exception ex) {
			std::cout << ex.what();
		}
	}
};


Size2D WriteMatrixSize() {
	Size2D size;
	do
	{
		std::cin >> size.x >> size.y;
	} while (size.x <= 0 || size.y <= 0);
	return size;
}

int ChoiseFillingMethod() {
	int k;
	do
	{
		std::cout << "Выберите способ заполнения матриц\n" <<
			"1 - Вручную \n2 - Случайным образом\n";
		std::cin >> k;
	} while (k < 1 || k > 2);
	return k;
}

int main()
{
	srand(time(NULL));
	system("chcp 1251");
	std::cout << "Вас приветствует программа" << std::endl <<
		"быстрого перемножения матриц методом Штрассена\n\n";


	///////////////////////////////////////////////////////////////////////////////
	////////////////////Ввод размеров матрицы пользователем////////////////////////
	///////////////////////////////////////////////////////////////////////////////

	std::cout << "Введите размеры первой матрицы\n";
	Matrix* matrix1 = new Matrix(WriteMatrixSize());
	std::cout << "Введите размеры второй матрицы\n";
	Matrix* matrix2 = new Matrix(WriteMatrixSize());


	///////////////////////////////////////////////////////////////////////////////
	////////////////Выбор способа заполнения и заполнение матриц///////////////////
	///////////////////////////////////////////////////////////////////////////////

	switch (ChoiseFillingMethod())
	{
	case 1:
		matrix1->fillValues();
		matrix2->fillValues();
		break;
	case 2:
		matrix1->fillValues(true);
		matrix2->fillValues(true);
		break;
	}

	std::cout << "\nМатрица 1\n\n";
	matrix1->show();
	std::cout << "\nМатрица 2\n\n";
	matrix2->show();


	///////////////////////////////////////////////////////////////////////////////
	/////////////////Приведение матриц к требуемому размеру////////////////////////
	///////////////////////////////////////////////////////////////////////////////

	int l = 2;
	while (l < matrix1->getSize().x || l < matrix1->getSize().y || l < matrix2->getSize().x || l < matrix2->getSize().y) l *= 2;

	Matrix* restoredMatrix1 = new Matrix(Size2D{ l,l }, true);
	Matrix* restoredMatrix2 = new Matrix(Size2D{ l,l }, true);

	for (int i = 0; i < matrix1->getSize().x; i++)
	{
		for (int j = 0; j < matrix1->getSize().y; j++)
			restoredMatrix1->values[i][j] = matrix1->values[i][j];
	}
	for (int i = 0; i < matrix2->getSize().x; i++)
	{
		for (int j = 0; j < matrix2->getSize().y; j++)
			restoredMatrix2->values[i][j] = matrix2->values[i][j];
	}

	std::cout << "Приведенные матрицы\n";
	std::cout << "\nМатрица 1\n\n";
	restoredMatrix1->show();
	std::cout << "\nМатрица 2\n\n";
	restoredMatrix2->show();


	///////////////////////////////////////////////////////////////////////////////
	///////////////Разбиение матриц на подматрицы и их заполнение//////////////////
	///////////////////////////////////////////////////////////////////////////////

	const int submatrixLen = 4;
	Matrix* submatrixes1[submatrixLen];
	for (int i = 0; i < submatrixLen; i++) {
		submatrixes1[i] = new Matrix(Size2D{ l / 2, l / 2 });
	}
	submatrixes1[0]->fillValues(restoredMatrix1, 0, 0);
	submatrixes1[1]->fillValues(restoredMatrix1, 0, l / 2);
	submatrixes1[2]->fillValues(restoredMatrix1, l / 2, 0);
	submatrixes1[3]->fillValues(restoredMatrix1, l / 2, l / 2);

	Matrix* submatrixes2[submatrixLen];
	for (int i = 0; i < submatrixLen; i++) {
		submatrixes2[i] = new Matrix(Size2D{ l / 2, l / 2 });
	}
	submatrixes2[0]->fillValues(restoredMatrix2, 0, 0);
	submatrixes2[1]->fillValues(restoredMatrix2, 0, l / 2);
	submatrixes2[2]->fillValues(restoredMatrix2, l / 2, 0);
	submatrixes2[3]->fillValues(restoredMatrix2, l / 2, l / 2);


	///////////////////////////////////////////////////////////////////////////////
	////////////////////////Создание промежуточных матриц//////////////////////////
	///////////////////////////////////////////////////////////////////////////////

	const int intermedmatrixLen = 7;
	Matrix* intermediateMatrixes[intermedmatrixLen];
	for (int i = 0; i < intermedmatrixLen; i++) {
		intermediateMatrixes[i] = new Matrix(Size2D{ l / 2, l / 2 }, true);
	};


	///////////////////////////////////////////////////////////////////////////////
	////////////////////Вычисление значений промежуточных матриц///////////////////
	///////////////////////////////////////////////////////////////////////////////

	for (int i = 0; i < l / 2; i++)
	{
		for (int j = 0; j < l / 2; j++)
		{
			for (int z = 0; z < l / 2; z++)
			{
				intermediateMatrixes[0]->values[i][j] += (submatrixes1[0]->values[i][z] + submatrixes1[3]->values[i][z]) * (submatrixes2[0]->values[z][j] + submatrixes2[3]->values[z][j]);
				intermediateMatrixes[1]->values[i][j] += (submatrixes1[2]->values[i][z] + submatrixes1[3]->values[i][z]) * submatrixes2[0]->values[z][j];
				intermediateMatrixes[2]->values[i][j] += submatrixes1[0]->values[i][z] * (submatrixes2[1]->values[z][j] - submatrixes2[3]->values[z][j]);
				intermediateMatrixes[3]->values[i][j] += submatrixes1[3]->values[i][z] * (submatrixes2[2]->values[z][j] - submatrixes2[0]->values[z][j]);
				intermediateMatrixes[4]->values[i][j] += (submatrixes1[0]->values[i][z] + submatrixes1[1]->values[i][z]) * submatrixes2[3]->values[z][j];
				intermediateMatrixes[5]->values[i][j] += (submatrixes1[2]->values[i][z] - submatrixes1[0]->values[i][z]) * (submatrixes2[0]->values[z][j] + submatrixes2[1]->values[z][j]);
				intermediateMatrixes[6]->values[i][j] += (submatrixes1[1]->values[i][z] - submatrixes1[3]->values[i][z]) * (submatrixes2[2]->values[z][j] + submatrixes2[3]->values[z][j]);
			}

		}
	}


	///////////////////////////////////////////////////////////////////////////////
	///////////////////////Создание вспомогательных матриц/////////////////////////
	///////////////////////////////////////////////////////////////////////////////

	const int assistmatrixLen = 4;
	Matrix* assistiveMatrixes[assistmatrixLen];
	for (int i = 0; i < assistmatrixLen; i++) {
		assistiveMatrixes[i] = new Matrix(Size2D{ l / 2,l / 2 });
	}


	///////////////////////////////////////////////////////////////////////////////
	////////////Подсчет значений вспомогательных матриц из промежуточных///////////
	///////////////////////////////////////////////////////////////////////////////

	for (int i = 0; i < l / 2; i++)
	{
		for (int j = 0; j < l / 2; j++)
		{
			assistiveMatrixes[0]->values[i][j] = intermediateMatrixes[0]->values[i][j] + intermediateMatrixes[3]->values[i][j] - intermediateMatrixes[4]->values[i][j] + intermediateMatrixes[6]->values[i][j];
			assistiveMatrixes[1]->values[i][j] = intermediateMatrixes[2]->values[i][j] + intermediateMatrixes[4]->values[i][j];
			assistiveMatrixes[2]->values[i][j] = intermediateMatrixes[1]->values[i][j] + intermediateMatrixes[3]->values[i][j];
			assistiveMatrixes[3]->values[i][j] = intermediateMatrixes[0]->values[i][j] - intermediateMatrixes[1]->values[i][j] + intermediateMatrixes[2]->values[i][j] + intermediateMatrixes[5]->values[i][j];
		}
	}


	///////////////////////////////////////////////////////////////////////////////
	///////////////////Создание результирующей матрицы/////////////////////////////
	///////////////////////////////////////////////////////////////////////////////

	Matrix* resultMatrix = new Matrix(Size2D{ l, l });


	///////////////////////////////////////////////////////////////////////////////
	///////Занесение информации из вспомогательных матриц в результирующую/////////
	///////////////////////////////////////////////////////////////////////////////

	for (int i = 0; i < l / 2; i++)
	{
		for (int j = 0; j < l / 2; j++)
		{
			resultMatrix->values[i][j] = assistiveMatrixes[0]->values[i][j];
			resultMatrix->values[i][j + l / 2] = assistiveMatrixes[1]->values[i][j];
			resultMatrix->values[i + l / 2][j] = assistiveMatrixes[2]->values[i][j];
			resultMatrix->values[i + l / 2][j + l / 2] = assistiveMatrixes[3]->values[i][j];
		}
	}


	///////////////////////////////////////////////////////////////////////////////
	////////////////Выравнивание границ результирующей матрицы/////////////////////
	///////////////////////////////////////////////////////////////////////////////

	int x = 0, y = 0, f = 100, s = 100;
	for (int i = 0; i < l; i++)
	{
		x = 0;
		y = 0;
		for (int j = 0; j < l; j++)
		{
			if (resultMatrix->values[i][j] != 0)
			{
				x++;
				f = 100;
			}
			if (resultMatrix->values[j][i] != 0)
			{
				y++;
				s = 100;
			}
		}
		if (x == 0 && i < f)
		{
			f = i;
		}
		if (y == 0 && i < s)
		{
			s = i;
		}
	}

	Matrix* finalMatrix = new Matrix(Size2D{ f, s });
	finalMatrix->fillValues(resultMatrix);


	///////////////////////////////////////////////////////////////////////////////
	///////////////////Вывод результирующей матрицы////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////

	std::cout << "\nРезультирующая матрица\n\n";
	finalMatrix->show();

	system("pause");

	///////////////////////////////////////////////////////////////////////////////
	/////////////////////Очистка динамической памяти///////////////////////////////
	///////////////////////////////////////////////////////////////////////////////

	for (int i = 0; i < matrix1->getSize().x; i++)
		delete[] matrix1->values[i];
	for (int i = 0; i < matrix2->getSize().x; i++)
		delete[] matrix2->values[i];
	for (int i = 0; i < l; i++)
	{
		delete[] restoredMatrix1->values[i];
		delete[] restoredMatrix2->values[i];
		delete[] resultMatrix->values[i];
	}
	for (int i = 0; i < f; i++)
		delete[] finalMatrix->values[i];
	for (int i = 0; i < l / 2; i++)
	{
		for (int j = 0; j < intermedmatrixLen; j++) {
			delete[] intermediateMatrixes[j]->values[i];
		}
		for (int j = 0; j < submatrixLen; j++) {
			delete[] submatrixes1[j]->values[i];
			delete[] submatrixes2[j]->values[i];
		}
		for (int j = 0; j < assistmatrixLen; j++) {
			delete[] assistiveMatrixes[j]->values[i];
		}
	}
	delete[] matrix1->values, matrix2->values, restoredMatrix1->values, restoredMatrix2->values, resultMatrix->values, finalMatrix->values;
	for (int j = 0; j < intermedmatrixLen; j++) {
		delete[] intermediateMatrixes[j]->values;
	}
	for (int j = 0; j < submatrixLen; j++) {
		delete[] submatrixes1[j]->values;
		delete[] submatrixes2[j]->values;
	}
	for (int j = 0; j < assistmatrixLen; j++) {
		delete[] assistiveMatrixes[j]->values;
	}

	return 0;
}