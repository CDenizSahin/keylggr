# kydnz — Güvenlik Araştırması (Etik ve Yasal Kullanım)

Bu depo, yalnızca eğitimsel ve savunma amaçlı güvenlik araştırmalarını desteklemek üzere hazırlanmıştır. Her türlü çalışma; kullanıcı rızası, yasal mevzuata uyum ve etik ilkeler çerçevesinde yürütülmelidir. Bu proje, üçüncü tarafların gizliliğini ihlal etmeyi veya yetkisiz erişimi kesinlikle teşvik etmez.

## Amaç

- Yalnızca kontrollü ve izole laboratuvar ortamlarında, kullanıcı rızası alınmış senaryolarda güvenlik farkındalığı oluşturmak
- Zararlı yazılımlara karşı savunma, tespit ve olay müdahalesi bakış açısı kazandırmak
- Kod ve mimari kararlarını etik ve yasal sınırlar dahilinde belgelendirmek

## Kapsam ve Sınırlar

- Bu depo, gerçek sistemlere veya üçüncü taraflara karşı kullanılmak üzere tasarlanmamıştır.
- Her türlü test, yalnızca sizin sahip olduğunuz veya açıkça izin aldığınız cihazlarda yapılmalıdır.
- Üçüncü taraf verileri (kişisel/duyarlı bilgiler dahil) kesinlikle toplanmamalı, işlenmemelidir.

## Hukuki Uyum ve Etik İlkeler

- İlgili ülke ve bölge yasalarına bütünüyle uyun.
- Kullanıcı rızası olmadan veri toplama, izleme, engelleme veya manipülasyon yapılmaz.
- Gizlilik, veri minimizasyonu ve amaçla sınırlılık ilkelerine uyulur.

## Rıza ve Bilgilendirme

- Teste dahil tüm kullanıcılar; amaç, kapsam, süre, toplanacak veriler ve riskler hakkında açıkça bilgilendirilmelidir.
- Yazılı onay (rıza) alınmalı ve kayıt altına tutulmalıdır.

## Güvenli Test Ortamı (Lab)

- İzole sanal makine veya kapalı ağ ortamı kullanın (snapshot/geri alma noktalarıyla).
- Sadece sentetik, hayali ve kişisel olmayan test verileri üretin.
- Test bittiğinde ortamı geri alın veya tamamen temizleyin.

## Veri Kullanımı ve Saklama

- Varsayılan politika: veri toplama yapmamak. Gerekliyse, en aza indirin ve anonimleştirin.
- Verileri yalnızca deney süresiyle sınırlı tutun; sürenin sonunda güvenli biçimde imha edin.
- Verilere erişimi yetki ve gereklilik prensipleriyle sınırlandırın.

## Tespit ve Savunma Perspektifi (Eğitsel)

- Gözlemlenebilecek savunma yaklaşımları: imza ve davranış analizleri, EDR/AV alarmları, kayıt (logging) korelasyonları.
- Uygun olduğunda; Windows Defender, EDR araçları ve Olay Görüntüleyicisi ile alarm/veri akışlarını laboratuvarınızda inceleyin.

## Kaldırma ve Temizlik

- Test sırasında oluşturulan yardımcı bileşenleri lab dışına taşımayın.
- Çalışma tamamlandığında tüm artıkları kaldırın, snapshot’ı geri yükleyin ve ortamı doğrulayın.

## Sorumlu Açıklama (Responsible Disclosure)

- Herhangi bir güvenlik açığı tespit ederseniz, ilgili taraflarla koordineli ve sorumlu açıklama süreçlerini takip edin.
- Kamuya açıklama öncesi; düzeltme için makul süre tanıyın ve hassas ayrıntıları paylaşmayın.

## Çalıştırma (Sadece Lab Ortamında)

### Gereksinimler
- Windows 10 veya üzeri
- Visual Studio 2022+ (".NET Desktop Development" iş yükü) veya hedef çerçeveye uygun .NET SDK

### Adımlar
1. Depoyu indirin veya kopyalayın.
2. Çözüm dosyasını (`.sln`) Visual Studio ile açın.
3. Başlangıç projesini seçin (WinForms proje).
4. Lab ortamında, izole ağda çalıştırın. Lab dışına çıkarılmamalıdır.

Komut satırı (uygunsa):

```bash
dotnet build
dotnet run
```

> Not: Hedef .NET Framework ise Visual Studio ile çalıştırmanız önerilir.

## Proje Yapısı (Özet)

```
kydnz/
├─ README.md
└─ games/
   └─ games/
      ├─ Form1.cs
      └─ ...
```

## Geliştirme Notları

- Kod okunabilirliği ve bakım kolaylığı önceliklidir.
- Yeni deneyler eklerken izolasyon, rıza ve veri minimizasyonu ilkelerine uyun.
- Büyük değişikliklerde küçük ve odaklı commit’ler atın; değişiklikleri belgeleyin.

## Test videosu

[YouTube - Test videosu](https://youtu.be/r_LvIWJCcRE)

## Sorumluluk Reddi

Bu deposu kullanarak, tüm faaliyetleri yalnızca yasal ve etik sınırlar içinde, rıza alınmış ve izole bir laboratuvar ortamında gerçekleştirmeyi kabul edersiniz. Yazarlar, üçüncü taraflara karşı yapılabilecek yetkisiz, etik dışı veya yasa dışı faaliyetlerden sorumlu tutulamaz.


