import 'package:image_gallery/models/picture.dart';

class Picture_Database {
  static final Picture_Database _instance = Picture_Database._internal();

  factory Picture_Database() {
    return _instance;
  }

  Picture_Database._internal();

  Stream<List<Picture>> getProductsBatched() async* {
    List<Picture> allProducts = [];

    var i = 0;
    while (i < 10) {
      await Future.delayed(Duration(seconds: 0), () {
        allProducts.add(_productsInDatabase[i]);
      });
      i++;
      yield allProducts;
    }
  }

  List<Picture> _productsInDatabase = [
    Picture('Carrot'),
    Picture('Potatoes'),
    Picture('Tomato'),
    Picture('Cheese'),
    Picture('Beans'),
    Picture('Lettuce'),
    Picture('Flour'),
    Picture('Honey'),
    Picture('Chocolat'),
    Picture('Asparagu'),
    Picture('Bread'),
  ];
}
