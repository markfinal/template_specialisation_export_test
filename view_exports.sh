#!/bin/bash

if [ "$(uname)" == "Darwin" ]; then
    nm -gU build/tempspecexport/Debug/libDynamicLibraryWithExports.1.dylib
    objdump -exports-trie build/tempspecexport/Debug/libDynamicLibraryWithExports.1.dylib
else
    nm -D build/tempspecexport/DynamicLibraryWithExports/Debug/bin/libDynamicLibraryWithExports.so.1.0.0
fi
