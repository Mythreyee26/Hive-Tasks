helm create dotnet-env-chart
minikube addons enable ingress

kubectl create namespace dotnet || true
helm upgrade --install dotnet-env ./dotnet-env-chart -n dotnet   --set image.repository=mythreyeegp/dotnetapp   --set image.tag=v2

<!-- for checking purpose -->
kubectl get all -n dotnet
kubectl get svc -n dotnet
kubectl port-forward svc/dotnet-env-dotnet-env-svc 8080:80 -n dotnet
kubectl get all -n dotnet
helm lint ./dotnet-env-chart
helm upgrade --install dotnet-env ./dotnet-env-chart -n dotnet   
kubectl get pods -n dotnet
kubectl get svc -n dotnet
kubectl get ingress -n dotnet


kubectl patch svc dotnet-env-dotnet-env-svc -n dotnet \ -p '{"spec": {"type": "LoadBalancer"}}'

kubectl get svc -n dotnet
minikube tunnel
kgs

hostfile change --> loadbalancer public ip dotnet-env.local  (http://dotnet-env.local/)
