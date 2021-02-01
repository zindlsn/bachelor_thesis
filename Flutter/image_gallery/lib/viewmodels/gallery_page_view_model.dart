import 'package:flutter/cupertino.dart';
import 'package:image_gallery/models/picture.dart';
import 'package:image_gallery/services/picture_service.dart';

class GalleryPageViewModel extends ChangeNotifier {
  List<Picture> productsz = [];

  PictureService pictureService = PictureService();

  Future fetchPictures() async {
      this.productsz = await pictureService.getCommentsForPost();
      return  this.productsz;
  }

  void addToCart(Picture product) => productsz.add(product);

  void removeFromCart(Picture product) {
    productsz.remove(product);
    notifyListeners();
  }
}
