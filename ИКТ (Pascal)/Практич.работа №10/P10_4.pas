{Тимушев 142гр}
Program P10_4;
uses crt;
type mas = array[1..9,1..9] of integer;
var 
    i,j,k:integer;
    D:array [1..9,1..9] of integer;
begin
randomize;
for i:=1 to 9 do begin
for j:=1 to 9 do begin
D[i,j]:=random(60)-30;
write(D[i,j]:4);
end;
writeln; 
end;  
k:=0;
for i:=1 to 9 do begin
for j:=1 to 9 do begin
if D[i,j]<0 then 
k:=k+1;
end;end; 
writeLn('Количество отрицательных элементов массива: ', k);
end.