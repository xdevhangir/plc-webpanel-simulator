FROM python:3.13-slim

WORKDIR /app

# Gereksinim dosyasını kopyala ve yükle
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# Proje dosyalarını kopyala
COPY WebPanelApp/ ./WebPanelApp

# Çalışma dizinine geç
WORKDIR /app/WebPanelApp

# Uygulamayı çalıştır
CMD ["python", "app.py"]

EXPOSE 5000
