{Тимушев 142гр}
Program P9_4;
uses crt;
type mas = array [1..10] of integer;
var C : mas;
    i,k: integer;          
begin
randomize;
for i:=1 to 10 do
begin
C[i]:=random(31)-15;
write(C[i]:4);
end;
writeln;
k:=0;
for i:=1 to 10 do begin
if C[i]<0 then begin
k:=k+1
end;end;
writeLn('Количество отрицательных элементов массива: ', k); 
for i:=1 to 10 do begin
if C[i]<0 then 
C[i]:=sqr(C[i]);
end;
writeLn('Отрицательный элемент массива в квадрате: ', C[i]);
end.