FROM mcr.microsoft.com/mssql/server:2019-latest
USER root
COPY ./Db /
RUN chmod +x ./run-initialization.sh
CMD /bin/bash ./entrypoint.sh