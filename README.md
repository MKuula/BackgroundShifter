# Background Shifter
Background Shifter gives you its helping hand when you need to create some great backgrounds for games, webpages, books, walls etc. It will not actually create graphics itself but makes them slightly more interesting.

To be exact, it takes a drawing, photograph or any else picture as input and duplicates it by a preferred amount (currently 5 times but you can tweak it in the code) and shifts it a bit in y-axis. So, the second picture would be higher or lower than the first one. Same applies for the third and so forth.

Think about a metal tiled background. If the metal plates are placed in the line with each other, the background can be boring to watch. To make it a sligthly better, the plates should be placed partly randomly in the vertical direction.

To accomplish this task, the plates have to be cut in the middle (or higher/lower) and the pieces swapped together. That is, draw an imaginary line across the metal plate, cut the plate, drag an upper part in the place of lower part and vice versa. Voila, you now have a slightly shifted plate. Please note that you will not rotate, mirror or flip the tiles, just reverse their order.

![image](https://github.com/MKuula/BackgroundShifter/assets/168563015/83401a40-818b-4442-92fd-ea63290227a7)

![image](https://github.com/MKuula/BackgroundShifter/assets/168563015/f7338c05-2cbf-45de-92e0-2b7bac9bd0f2)

![image](https://github.com/MKuula/BackgroundShifter/assets/168563015/c0d17c64-6a67-4da4-9f56-215f46b9f028)

## Technical things
Program has two Bitmap objects, one for the original bitmap and second for the modified ones. Like I said above, the result consists of multiple bitmaps so the application reserves space for them. In our example, I decided to duplicate the original bitmap five times. At first, the program has to pull the empty result bitmap object wide enough. For instance, if you have a 32×32-sized bitmap, the result bitmap will be 160×32-size.

DrawBitmap-routine has a loop which handles the copying of lower and upper parts. It takes the lower part of the original bitmap and copy it as an upper part to the result bitmap and vice versa. This, however, is so simple only if the cutpoint is located in the middle; otherwise the exact position must be calculated.

The main window displays two pictures, the original bitmap on the top and the result bitmap at the bottom.

## How do I use it?
You see three links at the bottom? Good. Click ”Open original” and select some picture, preferably a small one. If all went well, you should see the picture six times; the original at the top and the modified ones (a total of five) below it. If you are happy with the results, strike the ”Save result” and select desired filename for your artwork. Assuming that you are dissatisfied with the results, hit Reshift.
