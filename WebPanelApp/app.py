from flask import Flask, render_template, request

app = Flask(__name__)

@app.route('/', methods=['GET', 'POST'])
def index():
    status = "Bağlantı Yok"
    veri = ""
    if request.method == 'POST':
        status = "Bağlı"
        veri = request.form.get('giris_verisi')
    return render_template('index.html', status=status, veri=veri)

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
