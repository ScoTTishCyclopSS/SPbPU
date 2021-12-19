{Тимушев 142гр}
Program P9_123;
uses crt;
type mas = array [1..10] of integer;
var C : mas;
    i,k: integer;
    x,p: real;
begin
randomize;
for i:=1 to 10 do
begin
C[i]:=random(31)-15;
write(C[i]:4);
end;
writeln;
p:=1;
Writeln('Введите число: ');
Readln(x);
for i:=1 to 10 do begin
if C[i]<x then
p:=p*C[i];
end;
writeln('Произведение элементов массива равно: ',p);
writeln;
writeln('Элементы массива, кратные своим порядковым номерам: ');
for i:=1 to 10 do begin
if C[i] mod i=0 then writeln(i,':',C[i]:4);
end;
k:=0;
for i:=1 to 10 do begin
if C[i]<0 then begin
k:=k+1
end;end;
writeLn('Количество отрицательных элементов массива: ', k);
end.
