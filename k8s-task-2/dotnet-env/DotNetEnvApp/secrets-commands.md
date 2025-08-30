 echo -n "Docker" | base64
echo -n "Docker_connection_to_go" | base64
RG9ja2Vy
RG9ja2VyX2Nvbm5lY3Rpb25fdG9fZ28=

secret.yaml

apiVersion: v1
kind: Secret
metadata:
  name: dotnet-env-secret
type: Opaque
data:
  ASPNETCORE_ENVIRONMENT: RG9ja2Vy     # "Docker" (base64 encoded)
  Database__ConnectionString: RG9ja2VyX2Nvbm5lY3Rpb25fdG9fZ28=   # "Docker_connection_to_go"


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

