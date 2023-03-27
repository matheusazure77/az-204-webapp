FROM mysql:latest AS base
ENV MYSQL_ROOT_PASSWORD Azure123
ENV MYSQL_DATABASE appdb
COPY ./scriptsmysql/ /docker-entrypoint-initdb.d/