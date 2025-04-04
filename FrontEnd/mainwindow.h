#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include "screenLogin.h"
#include <QMainWindow>
#include "QStackedWidget"

QT_BEGIN_NAMESPACE
namespace Ui {
class MainWindow;
}
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private:
    Ui::MainWindow *ui;
    ScreenLogin *screenLogin;

};
#endif // MAINWINDOW_H
