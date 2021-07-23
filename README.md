# LC_Apollo
基于携程的分布式配置中心---Apollo讲解

## Apollo配置中心官网：https://www.apolloconfig.com/#/
![image](https://user-images.githubusercontent.com/26539681/126740704-40a1a9f1-781f-479b-840c-65eb618ab222.png)

## 基于centos7服务器的docker容器部署
![image](https://user-images.githubusercontent.com/26539681/126741218-670a0eb0-6a7c-4662-8483-5269929a7151.png)
![image](https://user-images.githubusercontent.com/26539681/126741332-7ea4d4c6-21f2-44df-9e47-5508eec50c23.png)
![image](https://user-images.githubusercontent.com/26539681/126741392-e28effd4-3bd6-447b-a124-cad4a1a064b2.png)
![image](https://user-images.githubusercontent.com/26539681/126741460-901ef648-e83c-436b-99e9-92f112c8794a.png)

## .NetCore3.1接入Apollo
1 nuget Com.Ctrip.Framework.Apollo.Configuration
![image](https://user-images.githubusercontent.com/26539681/126740784-a4697261-cd8e-4bc4-976a-aef46c8d4a07.png)

2 appsettings.json配置基础信息
![image](https://user-images.githubusercontent.com/26539681/126740829-efdbe695-c980-438f-b209-83f5c2d8f575.png)

3 Program注入Apollo
![image](https://user-images.githubusercontent.com/26539681/126740879-620032d1-b4e4-40e9-8fcf-8fc97647b786.png)

4 控制器或相关类注入IConfiguration，然后获取配置项
![image](https://user-images.githubusercontent.com/26539681/126740954-e1d7eb41-c954-4765-89c6-3407463494d3.png)
