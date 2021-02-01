import 'package:flutter/material.dart';
import 'package:image_gallery/services/picture_service.dart';
import 'package:image_gallery/viewmodels/gallery_page_view_model.dart';
import 'package:provider/provider.dart';

import 'models/picture.dart';

void main() {
  runApp(
    MultiProvider(
      providers: [
        FutureProvider<GalleryPageViewModel>(
            create: (_) => PictureService().getCommentsForPost()),
      ],
      child: MyApp(),
    ),
  );
}

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        // This is the theme of your application.
        //
        // Try running your application with "flutter run". You'll see the
        // application has a blue toolbar. Then, without quitting the app, try
        // changing the primarySwatch below to Colors.green and then invoke
        // "hot reload" (press "r" in the console where you ran "flutter run",
        // or simply save your changes to "hot reload" in a Flutter IDE).
        // Notice that the counter didn't reset back to zero; the application
        // is not restarted.
        primarySwatch: Colors.blue,
      ),
      home: MyHomePage(title: 'Image Gallery'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);

  final String title;

  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  @override
  Widget build(BuildContext context) {
    // This method is rerun every time setState is called, for instance as done
    // by the _incrementCounter method above.
    //
    // The Flutter framework has been optimized to make rerunning build methods
    // fast, so that you can just rebuild anything that needs updating rather
    // than having to individually change instances of widgets.
    return Scaffold(
      appBar: AppBar(
        // Here we take the value from the MyHomePage object that was created by
        // the App.build method, and use it to set our appbar title.
        title: Text(widget.title),
      ),
      body: FutureProvider<List<Picture>>(
        initialData: [],
        // using Provider to fetch a model and return a property from it? Fancy!
        create: (_) => (context) => GalleryPageViewModel().fetchPictures,
        catchError: (BuildContext context, error) => <Picture>[],
        // List equality has nothing to do with the elements in the list
        // Therefor, in order to tell Flutter that list has changed, we need to compare a
        // property of the list that will be different when elements are added or removed.
        updateShouldNotify: (List<Picture> last, List<Picture> next) =>
            last.length == next.length,
        builder: (BuildContext context, Widget child) {
          final items = context.watch<List<Picture>>(); // context.watch rules
          return ListView.builder(
            itemCount: items.length,
            itemBuilder: (BuildContext context, int index) {
              if (items.isEmpty) {
                return Text('no products for sale, check back later');
              }
              final item = items[index];
              return ListTile(
                title: Text(item.path ?? ''),
                onTap: () {
                  // notice that this calls a method on `Cart`,
                  // but Cart isn't used anywhere else on this page.
                  // This is an example of one model being shared across screens,
                  // And I promise its far easier than passing values from one
                  // screen to another during navigation
                  context.read<GalleryPageViewModel>().addToCart(item);
                },
              );
            },
          );
        },
      ),
      floatingActionButton: FloatingActionButton(
          tooltip: 'Increment',
          child: Icon(Icons.add),
          onPressed: () =>
              context.read<GalleryPageViewModel>().addToCart(null)), //
    );
  }
}
