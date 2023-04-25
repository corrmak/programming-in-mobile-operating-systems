первый этап:

docker stop $(docker ps -a -q)

docker container rm $(docker ps -a -q)

docker image prune -a

docker volume rm $(docker volume ls -q)

docker system prune -a

второй этап:

docker run -d --name registry-ui -p 8080:80 jc21/registry-ui

третий этап:

docker run -d --name shipyard --link registry-ui:registry-ui -v /var/run/docker.sock:/var/run/docker.sock shipyard/shipyard

Подключился к APIdocker: 
а)открыл порт 8000 
б)перешел по адресу моего сеанса в pwd 
в)ввел логин и пароль по умолчанию 
г)добавил реестр docker

четвертый этап:

docker run -d -p 80:80 --name my-apache httpd:latest

docker exec -it my-apache /bin/bash

ulimit -n 1024

Эта команда установит максимальное количество открытых файлов 1024
