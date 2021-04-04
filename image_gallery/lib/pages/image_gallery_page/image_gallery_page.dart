import 'package:flutter/material.dart';
import 'package:image_gallery/mvvm/base_model.dart';
import 'package:image_gallery/mvvm/base_view.dart';
import 'package:image_gallery/pages/image_gallery_page/image_gallery_page_view_model.dart';
import 'package:image_gallery/pages/image_gallery_page/image_view.dart';

class ImageGalleryPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return BaseView<ImageGalleryPageViewModel>(
      onModelReady: (model) async {},
      builder: (context, model, child) => Scaffold(
        appBar: AppBar(
          actions: [
            GestureDetector(
              onTap: () async {
                await model.changeThemeAsync();
              },
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: model.lightTheme
                    ? Icon(Icons.wb_sunny_outlined)
                    : Icon(Icons.wb_sunny),
              ),
            ),
          ],
        ),
        backgroundColor: Theme.of(context).backgroundColor,
        body: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(
            child: model.images.length > 0
                // https://rrtutors.com/tutorials/Flutter-GridView-and-Different-ways-of-Constructors
                ? Scrollbar(
                    isAlwaysShown: true,
                    child: GridView.count(
                      crossAxisCount: 5,
                      crossAxisSpacing: 10,
                      children: model.images.map((image) {
                        return ImageView(image: image);
                      }).toList(),
                    ),
                  )
                : model.state == ViewState.Idle
                    ? Center(
                        child: Text('No images loaded'),
                      )
                    : Center(
                        child: CircularProgressIndicator(),
                      ),
          ),
        ),
        floatingActionButton: FloatingActionButton(
          child: Icon(Icons.file_upload),
          onPressed: () async {
            await model.loadImagesAsync();
          },
        ),
      ),
    );
  }
}
//mike büttner, heio müller
