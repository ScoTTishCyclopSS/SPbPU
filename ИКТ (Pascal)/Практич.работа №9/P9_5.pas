{Тимушев 142гр}
Program P9_5;
uses crt;
type mas = array [1..10] of integer;
var C : mas;
    i,j,k: integer;          
begin
randomize;
for i:=1 to 10 do
begin
C[i]:=random(31)-15;
write(C[i]:4);
end;
writeln;
for i := 1 to 10-1 do
for j := 1 to 10-i do
if C[j] > C[j+1] then begin
k:= C[j];
C[j]:= C[j+1];
C[j+1]:=k
end;
writeln('Массив, отсортированный по возрастанию: ');
for i := 1 to 10 do
write (C[i]:4);
writeln;
readln
end.