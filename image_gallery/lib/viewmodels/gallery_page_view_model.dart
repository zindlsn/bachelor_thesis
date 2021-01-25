import 'package:flutter/cupertino.dart';
import 'package:image_gallery/models/picture.dart';

class GalleryPageViewModel extends ChangeNotifier {
  List<Picture> productsz = [];

  void addToCart(Picture product) => productsz.add(product);

  void removeFromCart(Picture product) {
    productsz.remove(product);
    notifyListeners();
  }
}
