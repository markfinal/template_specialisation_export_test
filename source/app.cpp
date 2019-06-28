#include "lib.h"

#include <iostream>

int main()
{
    const int ivalue = 42;
    const float fvalue = 3.14159f;
    std::cout << "General:     " << do_something(fvalue) << std::endl;
    std::cout << "Specialised: " << do_something(ivalue) << std::endl;
    return 0;
}
