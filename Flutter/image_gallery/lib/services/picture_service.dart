import 'dart:async';

import 'package:image_gallery/models/picture.dart';
import 'package:image_gallery/services/picture_database.dart';

class PictureService {
  StreamController<List<Picture>> _streamController =
      StreamController<List<Picture>>();

  Stream<List<Picture>> get allProductsForSale => _streamController.stream;

  PictureService() {
    _streamController.add(<Picture>[]);
    _initialize();
  }

  void _initialize() {
    Picture_Database().getProductsBatched().listen((List<Picture> products) {
      _streamController.add(products);
    });
  }

  void dispose() {
    _streamController.close();
  }

  Future<List<Picture>> getCommentsForPost() async {
    var comments = <Picture>[];

    Picture_Database().getProductsBatched().listen((List<Picture> products) {
      comments.addAll(products);
    });

    return comments;
  }
}
