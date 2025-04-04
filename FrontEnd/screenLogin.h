#ifndef SCREENLOGIN_H
#define SCREENLOGIN_H

#include <QMainWindow>
#include <QWidget>

QT_BEGIN_NAMESPACE
namespace Ui {
class ScreenLogin;
}
QT_END_NAMESPACE

class ScreenLogin : public QWidget
{
    Q_OBJECT
public:
    explicit ScreenLogin(QWidget *parent = nullptr);
    ~ScreenLogin();

signals:
    Ui::ScreenLogin *ui;
};

#endif // SCREENLOGIN_H
