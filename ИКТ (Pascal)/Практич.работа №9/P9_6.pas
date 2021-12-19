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
if C[i]<10 then begin
k:=k+1
end;end;
writeLn('Количество элементов массива меньше 10: ', k); 
end.