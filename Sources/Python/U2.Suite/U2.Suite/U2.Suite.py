from PySide2.QtWidgets import QtWidgets, QApplication
import sys
 
class Window(QtWidgets):
    def __init__(self):
        super().__init__()
 
        self.setWindowTitle("Pyside2 Window")
        self.setGeometry(300,300,500,400)
 
 
app = QApplication(sys.argv)
window=Window()
window.show()
app.exec_()

