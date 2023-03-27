FROM mysql:latest AS base
ENV MYSQL_DATABASE appdb
COPY ./scriptsmysql/ /docker-entrypoint-initdb.d/