{������� 142��}
Program P9_0;
uses crt;
type mas = array [1..10] of integer;
var C : mas;
    i: integer;          { ������� ������� C}
    x,p,k: real;
begin
randomize;
for i:=1 to 10 do
begin
C[i]:=random(31)-15;
writeln(C[i]);          {����� � �������}
end;
for i:=1 to 10 do
write(C[i]:4);          {����� � �������}
writeln;
end.

