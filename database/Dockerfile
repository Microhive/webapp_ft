FROM bitnami/mariadb:latest

ENV MARIADB_ROOT_PASSWORD=2YomMNEIaBrqxDesQGzeoGVuAwk7dJCG2oDjYZGUxVwfGpFIfL

ENV MARIADB_USER=loodse
ENV MARIADB_PASSWORD=Password123
ENV MARIADB_DATABASE=loodse

COPY --chown=nobody:nogroup ./loodse.dmp.sql /docker-entrypoint-initdb.d/1.insert.sql