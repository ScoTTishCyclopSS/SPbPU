{������� 142��}
Program P10_1;
uses crt;
type mas = array [1..9,1..9] of integer;
var D : mas;
    i,j,k,S: integer;          {������� ������� D, k-����������, S-�����}
    sr: real;              {������� ��������������}
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
S:=S+D[i,i];   {������� ���������� � ����� ������������� ��������� �������}
end;end;end;
sr:=S/k;
writeln('������� �������������� ������������� ��������� �������� ��������� �����: ', sr:6:3);
end.


