 {������� ����� 142��}
program P1_3;
uses crt;
var a, b, c: integer; {�������� ��������}
begin
     writeln('�������� ��������: ');
     a:=10; {�������� ��������}
     writeln('A=', a);
     b:=2; {�������� ��������}
     writeln('B=', b);
     c:=-6; {�������� ��������}
     writeln('C=', c);
     writeln;
     writeln('����������: ');
     A:=B*C-9;
     Writeln('A=B*C-9');
     Writeln('A= ',A);
     B:=6+C;
     C:=3*A+2*B;
     A:=B-C;
     Writeln('A=B-C');
     Writeln('A= ',A);
     Writeln('B=6+C');
     Writeln('B= ',B);
     Writeln('C=3*A+2*B');
     Writeln('C= ',C);
     B:=6+C;
     C:=3*A+2*B;
end. {����� ���������}