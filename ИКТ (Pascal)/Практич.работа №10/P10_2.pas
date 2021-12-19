{Тимушев 142гр}
Program P10_1;
uses crt;
type mas = array [1..9,1..9] of integer;
var D : mas;
    i,j: integer;          {индексы массива D}
begin
randomize;
for i:=1 to 9 do begin
for j:=1 to 9 do begin
D[i, j]:=random(61)-30;
write(D[i,j]:4);
end;
writeln;
end;
writeln('Измененный массив');
for i:=1 to 9 do begin
for j:=1 to 9 do begin
if D[i,j]<-5 then
D[i,j]:=0;
write(D[i,j]:4);
end;writeln;end;
writeln;
end.


