Определил точку монтирования Volume внутри контейнера. 

Внёс изменения в Dockerfile, где добавил команду VOLUME, которая указывает точку монтирования для VOLUME: VOLUME /app 

Собрал образ Docker

Ввёл: docker build -t nginx-dock 

Создал volume используя: docker volume create storage

Запустил контейнер подключив volume: docker run -v storage:/app -p 8080:80 nginx

Скопировал данные index.html внутрь volume:

docker run -v storage:/app -v /Users/Win10Pro/desktop/lab5:/data --rm alpine sh -c "cp /data/index.html /app/"

Для временного контейнера использовал образ alpine,а также команды sh -c для выполнения команд внутри контейнера

смотрю,чтобы index.html подгрузился внутрь Volume, запустив временный конейнер и проверил наличие файла docker run -v storage:/app --rm alpine sh -c "ls /app"
