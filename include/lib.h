#ifndef LIB_H
#define LIB_H

#if defined(_MSC_VER)
    #if defined(BUILD_LIB)
        #define LIB_API __declspec(dllexport)
    #else
        #define LIB_API __declspec(dllimport)
    #endif
#endif
#if !defined(LIB_API)
    #define LIB_API /* do nothing */
#endif

template <typename T>
const char *
do_something(const T& input)
{
    (void)input;
    return "an unspecialised type";
}

#if defined(_MSC_VER)
// Must have the template specialisation declared here
template<>
LIB_API const char*
do_something<int>(const int& input);
#endif

#endif // LIB_H
