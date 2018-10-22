unit EsbocoTela;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, DateTimePicker, Forms, Controls, Graphics,
  Dialogs, ExtCtrls, StdCtrls, Menus;

type

  { TTelaAssociacaoPSAComCT }

  TTelaAssociacaoPSAComCT = class(TForm)
    btnAtualizaCTIT: TButton;
    DateTimePicker1: TDateTimePicker;
    DateTimePicker2: TDateTimePicker;
    gridPSA: TGroupBox;
    Periodo: TGroupBox;
    gridCT: TGroupBox;
    GroupBox3: TGroupBox;
    Memo1: TMemo;
    Memo2: TMemo;
    Memo4: TMemo;
    Panel1: TPanel;
    Panel2: TPanel;
    Associados: TRadioGroup;
  private

  public

  end;

var
  TelaAssociacaoPSAComCT: TTelaAssociacaoPSAComCT;

implementation

{$R *.lfm}

end.

