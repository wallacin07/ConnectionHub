#include "screenLogin.h"
#include "ui_screenLogin.h"

ScreenLogin::ScreenLogin(QWidget *parent)
    : QWidget{parent}
    , ui(new Ui::ScreenLogin)
{
    ui->setupUi(this);
}
ScreenLogin::~ScreenLogin()
{
    delete ui;
}
{}

