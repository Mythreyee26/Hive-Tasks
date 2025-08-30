ingress.yaml:
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: dotnet-env-ingress
  namespace: default
  annotations:
    nginx.ingress.kubernetes.io/rewrite-target: /
spec:
  ingressClassName: nginx
  rules:
  - host: dotnet.local
    http:
      paths:
      - path: /
        pathType: Prefix
        backend:
          service:
            name: dotnet-env-service   # must match your service name
            port:
              number: 80               # must match service port


service.yaml:

apiVersion: v1
kind: Service
metadata:
  name: dotnet-env-service
spec:
  type: ClusterIP   # so you can access from browser
  selector:
    app: dotnet-env-app
  ports:
    - port: 80         # Service port
      targetPort: 80   # Container port


minikube addons enable ingress
kubectl apply -f configmap.yaml
kubectl apply -f secret.yaml
kubectl apply -f deployment.yaml
kubectl apply -f service.yaml
 kubectl apply -f ingress.yaml

 kubectl get ingress

kubectl get svc -n ingress-nginx

kubectl patch svc ingress-nginx-controller -n ingress-nginx \
  -p '{"spec": {"type": "LoadBalancer"}}'
kubectl get svc -n ingress-nginx

minikube tunnel


edit in the C:\Windows\System32\drivers\etc\hosts file with the external ip of the load balancer with dotnet.local


http://dotnet.local 
