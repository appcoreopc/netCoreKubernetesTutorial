# Build it 
# docker build -t dotnetapp-prod  .

# Run it
# docker run -d -p 5050:5050 dotnetapp-prod

# Browse it 
# http://192.168.99.100:5050/hello/index


# Pushing to repository
# 
# docker login 
# 
# docker tag dotnetapp-prod kepung/dotnetapp-prod
# docker push kepung/dotnetapp-prod


# To run it on KUBERNETES 
# minikube start
# minikube docker-env

# kubectl run 
# kubectl run connectcd --image=kepung/dotnetapp-prod --port=5050 
# Exposing kubernetes service 
# kubectl expose deployment/connectcd  --type="NodePort" --port=5050 --name=connectcd-http

# Get the minikube / kubernete ip and paste in your exposed IP 
# Look under Addresses:
#  InternalIP:  192.168.99.100
#  Hostname:    minikube

# kubectl describe node 

# kubectl get service/connectcd-http
# Get the port which looks something like this :- 
#NAME             TYPE       CLUSTER-IP      EXTERNAL-IP   PORT(S)          AGE
#connectcd-http   NodePort   10.103.83.222   <none>        5050:32206/TCP   8m

# Scaling it 
# kubectl scale deployment/connectcd --replicas=4


# Working on a real cluster - assuming that your config are in connect_config.txt file. 
# Run docker images on Kube cluster
# kubectl --kubeconfig connect_config.txt run connectcd --image=kepung/dotnetapp-prod --port=5050 
# Expose the port service 
# kubectl --kubeconfig connect_config.txt expose deployment/connectcd --type="LoadBalancer" --port=5050 --name=connectcd-http


# kubectl --kubeconfig connect_config.txt get services/connectcd-http -o wide or 
# kubectl --kubeconfig connect_config.txt get services/connectcd-http -o yaml

# you might get something like this. 

# apiVersion: v1
# kind: Service
# metadata:
#   creationTimestamp: 2018-02-21T23:53:19Z
#   labels:
#     run: connectcd
#   name: connectcd-http
#   namespace: default
#   resourceVersion: "13844785"
#   selfLink: /api/v1/namespaces/default/services/connectcd-http
#   uid: 6451ebb2-1762-11e8-9867-02432983db5c
# spec:
#   clusterIP: 100.68.35.189
#   externalTrafficPolicy: Cluster
#   ports:
#   - nodePort: 32426
#     port: 5050
#     protocol: TCP
#     targetPort: 5050
#   selector:
#     run: connectcd
#   sessionAffinity: None
#   type: LoadBalancer
# status:
#   loadBalancer:
#     ingress:
#     - hostname: a6451ebb2176211e8986702432983db5-1541704422.us-east-1.elb.amazonaws.com

# Other useful command 
# kubectl delete pods --all 


#Debugging and troubleshooting 
#kubectl get po then, 
#docker run -it dotnetapp-prod bash

#Kubernetes debugging 
#kubectl exec -it connectcd-545c87f8d8-k8hgz /bin/bash


# AWS support 
# docker build -t dotnetapp-prod .
# docker tag dotnetapp-prod 312611170176.dkr.ecr.ap-southeast-2.amazonaws.com/jeremy:dotnetapp-prod
# docker push 312611170176.dkr.ecr.ap-southeast-2.amazonaws.com/jeremy:dotnetapp-prod


FROM microsoft/dotnet:2.0-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -r linux-x64 -o out

# build runtime image
FROM microsoft/dotnet:2.0-runtime 
WORKDIR /app
COPY --from=build-env /app/out ./

ENTRYPOINT ["dotnet", "ConnectCD.NetCoreWebApi.dll"]