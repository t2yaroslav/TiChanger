FROM amazonlinux:2017.12
LABEL maintainer ""

WORKDIR /app

RUN yum -y update \
    && curl --silent --location https://rpm.nodesource.com/setup_6.x | bash - \
    && yum -y install nodejs bzip2 tar \
    && npm install jsreport-core jsreport-jsrender jsreport-phantom-pdf ngx-qrcode2 \
    && yum -y install libunwind libuuid icu freetype fontconfig

COPY build/ /app
COPY entrypoint.bash /app/entrypoint.bash
# COPY nginx.conf /etc/nginx/nginx.conf
# COPY nginx_default.conf /etc/nginx/sites-available/default.conf

RUN touch /etc/sysconfig/network \
    && chmod +x /app/entrypoint.bash

# Default environment if not specfied in ECS task
ENV ASPNETCORE_ENVIRONMENT test-linux-aurora
ENV ASPNETCORE_URLS http://*:80

EXPOSE 80

ENTRYPOINT [ "/app/TIC.Web" ]