docker build -t mythreyeegp/dotnetapp:v2 .
docker push mythreyeegp/dotnetapp:v2

minikube start
kubectl apply -f deployment.yaml
kubectl apply -f service.yaml
kubectl get pods
minikube service dotnet-env-service

changes in the deployment file
     # envFrom:
          #   - configMapRef:
          #       name: dotnet-env-config


kubectl rollout restart deployment dotnet-env-deployment

kubectl apply -f configmap.yaml
kubectl apply -f deployment.yaml
kubectl apply -f service.yaml

minikube service dotnet-env-service


kubectl delete -f configmap.yaml
kubectl delete -f deployment.yaml
kubectl delete -f service.yaml


 echo -n "Docker" | base64
echo -n "Docker_connection_to_go" | base64
RG9ja2Vy
RG9ja2VyX2Nvbm5lY3Rpb25fdG9fZ28=


kubectl apply -f secret.yaml
 kubectl apply -f deployment.yaml
minikube service dotnet-env-service

kubectl get secrets
NAME                TYPE     DATA   AGE
dotnet-env-secret   Opaque   2      3m41s

kubectl get secret dotnet-env-secret -o yaml

TO DECODE:
kubectl get secret dotnet-env-secret -o jsonpath='{.data.ASPNETCORE_ENVIRONMENT}' | base64 --decode

kgp

kubectl exec -it dotnet-env-deployment-6d868948d9-sgg6x  -- sh
# printenv | grep ASPNETCORE_ENVIRONMENT
#printenv | grep Database__ConnectionString

ASPNETCORE_ENVIRONMENT=Docker
Database__ConnectionString=Docker_connection_to_go

