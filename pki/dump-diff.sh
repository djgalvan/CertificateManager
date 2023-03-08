#!/bin/bash

cert9ReferenceTables=$(sqlite3 ./ref/cert9.db -cmd .tables .quit)
cert9TestTables=$(sqlite3 ./test/cert9.db -cmd .tables .quit)
cert9ReferenceDump=$(sqlite3 ./ref/cert9.db -cmd .dump .quit)
cert9TestDump=$(sqlite3 ./test/cert9.db -cmd .dump .quit)
{
  echo "$cert9ReferenceTables"
  echo "$cert9TestDump"
} > cert9-testdump.txt
{
  echo "$cert9TestTables"
  echo "$cert9ReferenceDump"
} > cert9-refdump.txt

key4ReferenceTables=$(sqlite3 ./ref/key4.db -cmd .tables .quit)
key4TestTables=$(sqlite3 ./test/key4.db -cmd .tables .quit)
key4ReferenceDump=$(sqlite3 ./ref/key4.db -cmd .dump .quit)
key4TestDump=$(sqlite3 ./test/key4.db -cmd .dump .quit)
{
  echo "$key4ReferenceTables"
  echo "$key4TestDump"
} > key4-testdump.txt
{
  echo "$key4TestTables"
  echo "$key4ReferenceDump"
} > key4-refdump.txt
