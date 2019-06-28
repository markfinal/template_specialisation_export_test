#include "lib.h"

// specialisation for an int
// MSVC: You can add LIB_API on this specialisation here (and not in the header) and it will export it, but the specialisation is never
// chosen by the compiler in another translation unit, as it's not aware of it. It needs to be in the header.
// If it's in the header, then the header declaration must have LIB_API, or you get C2375, different linkage warning.

// Clang(Xcode9): Same as for MSVC

// Gcc(4.8): Same as for MSVC
template<>
const char *
do_something<int>(const int& input)
{
    (void)input;
    return "an int";
}
