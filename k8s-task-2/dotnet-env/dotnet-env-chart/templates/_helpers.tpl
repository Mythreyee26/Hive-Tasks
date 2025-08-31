{{/* Chart helpers for dotnet-env */}}

{{- define "dotnet-env.name" -}}
{{- default .Chart.Name .Values.nameOverride }}
{{- end }}

{{- define "dotnet-env.fullname" -}}
{{- if .Values.fullnameOverride }}
{{- .Values.fullnameOverride | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- $name := default .Chart.Name .Values.nameOverride }}
{{- printf "%s-%s" .Release.Name $name | trunc 63 | trimSuffix "-" }}
{{- end }}
{{- end }}

{{- define "dotnet-env.labels" -}}
app.kubernetes.io/name: {{ include "dotnet-env.name" . }}
app.kubernetes.io/instance: {{ .Release.Name }}
app.kubernetes.io/version: {{ .Chart.AppVersion }}
app.kubernetes.io/managed-by: {{ .Release.Service }}
{{- end }}

{{- define "dotnet-env.serviceAccountName" -}}
{{- if .Values.serviceAccount.create -}}
{{- printf "%s-sa" (include "dotnet-env.fullname" .) -}}
{{- else -}}
{{- .Values.serviceAccount.name | default (include "dotnet-env.fullname" .) -}}
{{- end -}}
{{- end }}
