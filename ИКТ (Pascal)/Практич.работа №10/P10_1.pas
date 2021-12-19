{Тимушев 142гр}
Program P10_1;
uses crt;
type mas = array [1..9,1..9] of integer;
var D : mas;
    i,j,k,S: integer;          {индексы массива D, k-количество, S-сумма}
    sr: real;              {среднее арифметическое}
begin
randomize;
for i:=1 to 9 do begin
for j:=1 to 9 do begin
D[i, j]:=random(61)-30;
write(D[i,j]:4);
end;
writeln;
end;
for i:=1 to 9 do begin
for j:=1 to 9 do begin
if i+j=10 then  begin
k:=k+1;
S:=S+D[i,i];   {подсчет количества и суммы положительных элементов массива}
end;end;end;
sr:=S/k;
writeln('Среднее арифмитическое положительных элементов побочной диагонали равно: ', sr:6:3);
end.


