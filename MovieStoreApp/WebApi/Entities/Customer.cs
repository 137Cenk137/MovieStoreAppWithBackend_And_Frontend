/*
1.Bir filmin sahip olması gereken özellikleri şu şekildedir:

Film Adı
Film Yılı
Film Türü
Yönetmen
Oyuncular
Fiyat
Yönetmenler ve oyuncular ayrı tutulmalıdır. Bir oyuncu aynı zamanda yönetmen de olabilir, ama bunlar iki ayrı yapıdır.



2.Oyuncuların sahip olması gereken özellikler temelde şu şekildedir :

İsim
Soyisim
Oynadığı filmler
Bir filmde birden fazla oyuncu oynayabilir, bir oyuncunun da birden fazla filmi olabilir.



3.Yönetmenlerin sahip olması gereken özellikler temelde şu şekildedir:

İsim
Soyisim
Yönettiği filmler


4.Uygulama içerisinde bir de Customer rolü olmalıdır. Özellikleri ise temelde şu şekildedir:

İsim
Soyisim
Satın aldığı filmler

Müşterinin birden fazla favori film türü olabilir. Satın aldığı bir türü tekrar satın alabilir. Buraya bir kısıtlama koymaya gerek yok.



5.Customer için bir login endpoint'i yaratılmalıdır. Yetkisiz kullanıcı uygulama içerisinden satın alma işlemi yapamamalı.



6.Müşterilerin satın aldıkları filmler siparişlerim gibi bir yapı içerisinde tutulmalıdır. Temel özellikleri ise şu şekilde olmalıdır:



Satın alan müşteri
Satın alınan film
Fiyat
Satın alma tarihi
*/

public class Customer
{
    public ICollection<Movie> BoughtMovie  { get; set; }
}