Для создания приложения на flask: 
 1.Создал app.py и добавил туда
  from flask import Flask
  from pymongo import MongoClient
  app = Flask(__name__)
  # Подключение к MongoDB
  client = MongoClient('mongodb://mongo:27017')
  db = client['mydatabase']
  @app.route('/')
  def hello():
    return 'Hello,world!'
  if __name__ == '__main__':
    app.run(host='0.0.0.0')
 2.Создал Dockerfile и добавил туда
  FROM python:3.9-slim
  WORKDIR /app
  COPY requirements.txt .
  RUN pip install --no-cache-dir -r requirements.txt
  EXPOSE 5000
  CMD ["python", "app.py"]
 3.Создал requirements.txt и добавил туда
  Flask
  pymongo
4.Собрал докер образ docker build -t flask-app  5.Запустил контейнер docker run -p 5000:5000 --name flask-container --link mongo mongo flask-app
Для уменьшения образа использовал команду RUN pip install --no-cache-dir -r requirements.txt
Для исключения root из Dockerfile я добавил в него следующий код
FROM python:3.9-alpine
# Создание не-root пользователя
RUN adduser -D myuser
USER myuser
# Установка зависимостей
WORKDIR /app
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt
# Запуск приложения
CMD [ "python", "app.py" ]
Для проверки работоспособности я использовал docker ps и узнав id контейнера использовал docker logs 4a2b3c4d9e6f
