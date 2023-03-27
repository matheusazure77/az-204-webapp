sudo docker container stop mysqlcustom-1
sudo docker container rm mysqlcustom-1
sudo docker image rm mysqlcustom
sudo docker image rm appregistrymatheus.azurecr.io/mysqlcustom
sudo docker build -t mysqlcustom .
sudo docker run -d -p 3306:3306 --name mysqlcustom-1 -e MYSQL_ROOT_PASSWORD=Azure123 --platform linux/x86_64 mysqlcustom
sudo docker exec -it mysqlcustom-1 bash 
mysql -uroot -p